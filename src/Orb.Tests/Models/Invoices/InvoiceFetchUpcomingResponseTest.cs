using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
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
            ],
            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedInvoiceUrl = "hosted_invoice_url",
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
                            AppliesToPriceIds = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                    UsageCustomerIds = ["string"],
                },
            ],
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
            Memo = "memo",
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
        ];
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00");
        DateTimeOffset expectedEligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedHostedInvoiceUrl = "hosted_invoice_url";
        string expectedInvoiceNumber = "JYEFHK-00001";
        string expectedInvoicePdf =
            "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb";
        ApiEnum<string, Invoices::InvoiceSource> expectedInvoiceSource =
            Invoices::InvoiceSource.Subscription;
        DateTimeOffset expectedIssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedIssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Invoices::InvoiceFetchUpcomingResponseLineItem> expectedLineItems =
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
                        AppliesToPriceIds = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                UsageCustomerIds = ["string"],
            },
        ];
        Maximum expectedMaximum = new()
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
        };
        string expectedMaximumAmount = "maximum_amount";
        string expectedMemo = "memo";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
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
        Assert.Equal(expectedHostedInvoiceUrl, model.HostedInvoiceUrl);
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

    [Fact]
    public void SerializationRoundtrip_Works()
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
            ],
            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedInvoiceUrl = "hosted_invoice_url",
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
                            AppliesToPriceIds = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                    UsageCustomerIds = ["string"],
                },
            ],
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
            Memo = "memo",
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::InvoiceFetchUpcomingResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
            ],
            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedInvoiceUrl = "hosted_invoice_url",
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
                            AppliesToPriceIds = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                    UsageCustomerIds = ["string"],
                },
            ],
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
            Memo = "memo",
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::InvoiceFetchUpcomingResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        ];
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00");
        DateTimeOffset expectedEligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedHostedInvoiceUrl = "hosted_invoice_url";
        string expectedInvoiceNumber = "JYEFHK-00001";
        string expectedInvoicePdf =
            "https://assets.withorb.com/invoice/rUHdhmg45vY45DX/qEAeuYePaphGMdFb";
        ApiEnum<string, Invoices::InvoiceSource> expectedInvoiceSource =
            Invoices::InvoiceSource.Subscription;
        DateTimeOffset expectedIssueFailedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedIssuedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<Invoices::InvoiceFetchUpcomingResponseLineItem> expectedLineItems =
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
                        AppliesToPriceIds = ["string"],
                        Filters =
                        [
                            new()
                            {
                                Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                UsageCustomerIds = ["string"],
            },
        ];
        Maximum expectedMaximum = new()
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
        };
        string expectedMaximumAmount = "maximum_amount";
        string expectedMemo = "memo";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        Minimum expectedMinimum = new()
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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmountDue, deserialized.AmountDue);
        Assert.Equal(expectedAutoCollection, deserialized.AutoCollection);
        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditNotes.Count, deserialized.CreditNotes.Count);
        for (int i = 0; i < expectedCreditNotes.Count; i++)
        {
            Assert.Equal(expectedCreditNotes[i], deserialized.CreditNotes[i]);
        }
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(
            expectedCustomerBalanceTransactions.Count,
            deserialized.CustomerBalanceTransactions.Count
        );
        for (int i = 0; i < expectedCustomerBalanceTransactions.Count; i++)
        {
            Assert.Equal(
                expectedCustomerBalanceTransactions[i],
                deserialized.CustomerBalanceTransactions[i]
            );
        }
        Assert.Equal(expectedCustomerTaxID, deserialized.CustomerTaxID);
        Assert.True(JsonElement.DeepEquals(expectedDiscount, deserialized.Discount));
        Assert.Equal(expectedDiscounts.Count, deserialized.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], deserialized.Discounts[i]);
        }
        Assert.Equal(expectedDueDate, deserialized.DueDate);
        Assert.Equal(expectedEligibleToIssueAt, deserialized.EligibleToIssueAt);
        Assert.Equal(expectedHostedInvoiceUrl, deserialized.HostedInvoiceUrl);
        Assert.Equal(expectedInvoiceNumber, deserialized.InvoiceNumber);
        Assert.Equal(expectedInvoicePdf, deserialized.InvoicePdf);
        Assert.Equal(expectedInvoiceSource, deserialized.InvoiceSource);
        Assert.Equal(expectedIssueFailedAt, deserialized.IssueFailedAt);
        Assert.Equal(expectedIssuedAt, deserialized.IssuedAt);
        Assert.Equal(expectedLineItems.Count, deserialized.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], deserialized.LineItems[i]);
        }
        Assert.Equal(expectedMaximum, deserialized.Maximum);
        Assert.Equal(expectedMaximumAmount, deserialized.MaximumAmount);
        Assert.Equal(expectedMemo, deserialized.Memo);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedMinimum, deserialized.Minimum);
        Assert.Equal(expectedMinimumAmount, deserialized.MinimumAmount);
        Assert.Equal(expectedPaidAt, deserialized.PaidAt);
        Assert.Equal(expectedPaymentAttempts.Count, deserialized.PaymentAttempts.Count);
        for (int i = 0; i < expectedPaymentAttempts.Count; i++)
        {
            Assert.Equal(expectedPaymentAttempts[i], deserialized.PaymentAttempts[i]);
        }
        Assert.Equal(expectedPaymentFailedAt, deserialized.PaymentFailedAt);
        Assert.Equal(expectedPaymentStartedAt, deserialized.PaymentStartedAt);
        Assert.Equal(expectedScheduledIssueAt, deserialized.ScheduledIssueAt);
        Assert.Equal(expectedShippingAddress, deserialized.ShippingAddress);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
        Assert.Equal(expectedSubtotal, deserialized.Subtotal);
        Assert.Equal(expectedSyncFailedAt, deserialized.SyncFailedAt);
        Assert.Equal(expectedTargetDate, deserialized.TargetDate);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedVoidedAt, deserialized.VoidedAt);
        Assert.Equal(expectedWillAutoIssue, deserialized.WillAutoIssue);
    }

    [Fact]
    public void Validation_Works()
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
            ],
            DueDate = DateTimeOffset.Parse("2022-05-30T07:00:00+00:00"),
            EligibleToIssueAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            HostedInvoiceUrl = "hosted_invoice_url",
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
                            AppliesToPriceIds = ["string"],
                            Filters =
                            [
                                new()
                                {
                                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                                    Operator =
                                        MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
                    UsageCustomerIds = ["string"],
                },
            ],
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
            Memo = "memo",
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

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Invoices::AutoCollection
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::AutoCollection>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoices::AutoCollection
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::AutoCollection>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedEnabled = true;
        DateTimeOffset expectedNextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedNumAttempts = 0;
        DateTimeOffset expectedPreviouslyAttemptedAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedEnabled, deserialized.Enabled);
        Assert.Equal(expectedNextAttemptAt, deserialized.NextAttemptAt);
        Assert.Equal(expectedNumAttempts, deserialized.NumAttempts);
        Assert.Equal(expectedPreviouslyAttemptedAt, deserialized.PreviouslyAttemptedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Invoices::AutoCollection
        {
            Enabled = true,
            NextAttemptAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            NumAttempts = 0,
            PreviouslyAttemptedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::CreditNote>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::CreditNote>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreditNoteNumber = "credit_note_number";
        string expectedMemo = "memo";
        string expectedReason = "reason";
        string expectedTotal = "total";
        string expectedType = "type";
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreditNoteNumber, deserialized.CreditNoteNumber);
        Assert.Equal(expectedMemo, deserialized.Memo);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVoidedAt, deserialized.VoidedAt);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::CustomerBalanceTransaction>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::CustomerBalanceTransaction>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAction, deserialized.Action);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditNote, deserialized.CreditNote);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedEndingBalance, deserialized.EndingBalance);
        Assert.Equal(expectedInvoice, deserialized.Invoice);
        Assert.Equal(expectedStartingBalance, deserialized.StartingBalance);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }
}

public class ActionTest : TestBase
{
    [Theory]
    [InlineData(Invoices::Action.AppliedToInvoice)]
    [InlineData(Invoices::Action.ManualAdjustment)]
    [InlineData(Invoices::Action.ProratedRefund)]
    [InlineData(Invoices::Action.RevertProratedRefund)]
    [InlineData(Invoices::Action.ReturnFromVoiding)]
    [InlineData(Invoices::Action.CreditNoteApplied)]
    [InlineData(Invoices::Action.CreditNoteVoided)]
    [InlineData(Invoices::Action.OverpaymentRefund)]
    [InlineData(Invoices::Action.ExternalPayment)]
    [InlineData(Invoices::Action.SmallInvoiceCarryover)]
    public void Validation_Works(Invoices::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::Action> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::Action.AppliedToInvoice)]
    [InlineData(Invoices::Action.ManualAdjustment)]
    [InlineData(Invoices::Action.ProratedRefund)]
    [InlineData(Invoices::Action.RevertProratedRefund)]
    [InlineData(Invoices::Action.ReturnFromVoiding)]
    [InlineData(Invoices::Action.CreditNoteApplied)]
    [InlineData(Invoices::Action.CreditNoteVoided)]
    [InlineData(Invoices::Action.OverpaymentRefund)]
    [InlineData(Invoices::Action.ExternalPayment)]
    [InlineData(Invoices::Action.SmallInvoiceCarryover)]
    public void SerializationRoundtrip_Works(Invoices::Action rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::Action> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Action>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Action>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Invoices::Type.Increment)]
    [InlineData(Invoices::Type.Decrement)]
    public void Validation_Works(Invoices::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::Type.Increment)]
    [InlineData(Invoices::Type.Decrement)]
    public void SerializationRoundtrip_Works(Invoices::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceSourceTest : TestBase
{
    [Theory]
    [InlineData(Invoices::InvoiceSource.Subscription)]
    [InlineData(Invoices::InvoiceSource.Partial)]
    [InlineData(Invoices::InvoiceSource.OneOff)]
    public void Validation_Works(Invoices::InvoiceSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::InvoiceSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::InvoiceSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::InvoiceSource.Subscription)]
    [InlineData(Invoices::InvoiceSource.Partial)]
    [InlineData(Invoices::InvoiceSource.OneOff)]
    public void SerializationRoundtrip_Works(Invoices::InvoiceSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::InvoiceSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::InvoiceSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::InvoiceSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::InvoiceSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceFetchUpcomingResponseLineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Invoices::InvoiceFetchUpcomingResponseLineItem
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
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                            Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
            UsageCustomerIds = ["string"],
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
                AppliesToPriceIds = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
        List<string> expectedUsageCustomerIds = ["string"];

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
        var model = new Invoices::InvoiceFetchUpcomingResponseLineItem
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
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                            Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
            UsageCustomerIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Invoices::InvoiceFetchUpcomingResponseLineItem>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Invoices::InvoiceFetchUpcomingResponseLineItem
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
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                            Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
            UsageCustomerIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Invoices::InvoiceFetchUpcomingResponseLineItem>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAdjustedSubtotal = "5.00";
        List<Invoices::Adjustment> expectedAdjustments =
        [
            new MonetaryUsageDiscountAdjustment()
            {
                ID = "id",
                AdjustmentType = MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
                Amount = "amount",
                AppliesToPriceIds = ["string"],
                Filters =
                [
                    new()
                    {
                        Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                        Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
        List<string> expectedUsageCustomerIds = ["string"];

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
        var model = new Invoices::InvoiceFetchUpcomingResponseLineItem
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
                    AppliesToPriceIds = ["string"],
                    Filters =
                    [
                        new()
                        {
                            Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                            Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
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
            UsageCustomerIds = ["string"],
        };

        model.Validate();
    }
}

public class AdjustmentTest : TestBase
{
    [Fact]
    public void MonetaryUsageDiscountValidationWorks()
    {
        Invoices::Adjustment value = new MonetaryUsageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };
        value.Validate();
    }

    [Fact]
    public void MonetaryAmountDiscountValidationWorks()
    {
        Invoices::Adjustment value = new MonetaryAmountDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = AdjustmentType.AmountDiscount,
            Amount = "amount",
            AmountDiscount = "amount_discount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void MonetaryPercentageDiscountValidationWorks()
    {
        Invoices::Adjustment value = new MonetaryPercentageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void MonetaryMinimumValidationWorks()
    {
        Invoices::Adjustment value = new MonetaryMinimumAdjustment()
        {
            ID = "id",
            AdjustmentType = MonetaryMinimumAdjustmentAdjustmentType.Minimum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMinimumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void MonetaryMaximumValidationWorks()
    {
        Invoices::Adjustment value = new MonetaryMaximumAdjustment()
        {
            ID = "id",
            AdjustmentType = MonetaryMaximumAdjustmentAdjustmentType.Maximum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMaximumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        value.Validate();
    }

    [Fact]
    public void MonetaryUsageDiscountSerializationRoundtripWorks()
    {
        Invoices::Adjustment value = new MonetaryUsageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = MonetaryUsageDiscountAdjustmentAdjustmentType.UsageDiscount,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryUsageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryUsageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
            UsageDiscount = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonetaryAmountDiscountSerializationRoundtripWorks()
    {
        Invoices::Adjustment value = new MonetaryAmountDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = AdjustmentType.AmountDiscount,
            Amount = "amount",
            AmountDiscount = "amount_discount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryAmountDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryAmountDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonetaryPercentageDiscountSerializationRoundtripWorks()
    {
        Invoices::Adjustment value = new MonetaryPercentageDiscountAdjustment()
        {
            ID = "id",
            AdjustmentType = MonetaryPercentageDiscountAdjustmentAdjustmentType.PercentageDiscount,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryPercentageDiscountAdjustmentFilterField.PriceID,
                    Operator = MonetaryPercentageDiscountAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            PercentageDiscount = 0,
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonetaryMinimumSerializationRoundtripWorks()
    {
        Invoices::Adjustment value = new MonetaryMinimumAdjustment()
        {
            ID = "id",
            AdjustmentType = MonetaryMinimumAdjustmentAdjustmentType.Minimum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMinimumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMinimumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            ItemID = "item_id",
            MinimumAmount = "minimum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MonetaryMaximumSerializationRoundtripWorks()
    {
        Invoices::Adjustment value = new MonetaryMaximumAdjustment()
        {
            ID = "id",
            AdjustmentType = MonetaryMaximumAdjustmentAdjustmentType.Maximum,
            Amount = "amount",
            AppliesToPriceIds = ["string"],
            Filters =
            [
                new()
                {
                    Field = MonetaryMaximumAdjustmentFilterField.PriceID,
                    Operator = MonetaryMaximumAdjustmentFilterOperator.Includes,
                    Values = ["string"],
                },
            ],
            IsInvoiceLevel = true,
            MaximumAmount = "maximum_amount",
            Reason = "reason",
            ReplacesAdjustmentID = "replaces_adjustment_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::Adjustment>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubLineItemTest : TestBase
{
    [Fact]
    public void MatrixValidationWorks()
    {
        Invoices::SubLineItem value = new MatrixSubLineItem()
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,
            ScaledQuantity = 0,
        };
        value.Validate();
    }

    [Fact]
    public void TierValidationWorks()
    {
        Invoices::SubLineItem value = new TierSubLineItem()
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
            Type = TierSubLineItemType.Tier,
        };
        value.Validate();
    }

    [Fact]
    public void OtherValidationWorks()
    {
        Invoices::SubLineItem value = new OtherSubLineItem()
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            Type = OtherSubLineItemType.Null,
        };
        value.Validate();
    }

    [Fact]
    public void MatrixSerializationRoundtripWorks()
    {
        Invoices::SubLineItem value = new MatrixSubLineItem()
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            MatrixConfig = new(["string"]),
            Name = "Tier One",
            Quantity = 5,
            Type = MatrixSubLineItemType.Matrix,
            ScaledQuantity = 0,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::SubLineItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void TierSerializationRoundtripWorks()
    {
        Invoices::SubLineItem value = new TierSubLineItem()
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
            Type = TierSubLineItemType.Tier,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::SubLineItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OtherSerializationRoundtripWorks()
    {
        Invoices::SubLineItem value = new OtherSubLineItem()
        {
            Amount = "9.00",
            Grouping = new() { Key = "region", Value = "west" },
            Name = "Tier One",
            Quantity = 5,
            Type = OtherSubLineItemType.Null,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::SubLineItem>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::PaymentAttempt>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Invoices::PaymentAttempt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmount = "amount";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Invoices::PaymentProvider> expectedPaymentProvider =
            Invoices::PaymentProvider.Stripe;
        string expectedPaymentProviderID = "payment_provider_id";
        string expectedReceiptPdf =
            "https://assets.withorb.com/receipt/rUHdhmg45vY45DX/qEAeuYePaphGMdFb";
        bool expectedSucceeded = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPaymentProvider, deserialized.PaymentProvider);
        Assert.Equal(expectedPaymentProviderID, deserialized.PaymentProviderID);
        Assert.Equal(expectedReceiptPdf, deserialized.ReceiptPdf);
        Assert.Equal(expectedSucceeded, deserialized.Succeeded);
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }
}

public class PaymentProviderTest : TestBase
{
    [Theory]
    [InlineData(Invoices::PaymentProvider.Stripe)]
    public void Validation_Works(Invoices::PaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::PaymentProvider> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::PaymentProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::PaymentProvider.Stripe)]
    public void SerializationRoundtrip_Works(Invoices::PaymentProvider rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::PaymentProvider> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::PaymentProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Invoices::PaymentProvider>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Invoices::PaymentProvider>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class InvoiceFetchUpcomingResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(Invoices::InvoiceFetchUpcomingResponseStatus.Issued)]
    [InlineData(Invoices::InvoiceFetchUpcomingResponseStatus.Paid)]
    [InlineData(Invoices::InvoiceFetchUpcomingResponseStatus.Synced)]
    [InlineData(Invoices::InvoiceFetchUpcomingResponseStatus.Void)]
    [InlineData(Invoices::InvoiceFetchUpcomingResponseStatus.Draft)]
    public void Validation_Works(Invoices::InvoiceFetchUpcomingResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::InvoiceFetchUpcomingResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Invoices::InvoiceFetchUpcomingResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Invoices::InvoiceFetchUpcomingResponseStatus.Issued)]
    [InlineData(Invoices::InvoiceFetchUpcomingResponseStatus.Paid)]
    [InlineData(Invoices::InvoiceFetchUpcomingResponseStatus.Synced)]
    [InlineData(Invoices::InvoiceFetchUpcomingResponseStatus.Void)]
    [InlineData(Invoices::InvoiceFetchUpcomingResponseStatus.Draft)]
    public void SerializationRoundtrip_Works(Invoices::InvoiceFetchUpcomingResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Invoices::InvoiceFetchUpcomingResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoices::InvoiceFetchUpcomingResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Invoices::InvoiceFetchUpcomingResponseStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Invoices::InvoiceFetchUpcomingResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
