using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
using Orb.Exceptions;
using Orb.Models;

namespace Orb.Tests.Models;

public class SharedCreditNoteTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedCreditNote
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditNoteNumber = "credit_note_number",
            CreditNotePdf = "credit_note_pdf",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceID = "invoice_id",
            LineItems =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    ItemID = "item_id",
                    Name = "name",
                    Quantity = 0,
                    Subtotal = "subtotal",
                    TaxAmounts =
                    [
                        new()
                        {
                            Amount = "amount",
                            TaxRateDescription = "tax_rate_description",
                            TaxRatePercentage = "tax_rate_percentage",
                        },
                    ],
                    Discounts =
                    [
                        new()
                        {
                            ID = "id",
                            AmountApplied = "amount_applied",
                            AppliesToPriceIDs = ["string"],
                            DiscountType = DiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AmountDiscount = "amount_discount",
                            Reason = "reason",
                        },
                    ],
                    EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MaximumAmountAdjustment = new()
            {
                AmountApplied = "amount_applied",
                DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
                PercentageDiscount = 0,
                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                Reason = "reason",
            },
            Memo = "memo",
            MinimumAmountRefunded = "minimum_amount_refunded",
            Reason = Reason.Duplicate,
            Subtotal = "subtotal",
            Total = "total",
            Type = SharedCreditNoteType.Refund,
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Discounts =
            [
                new()
                {
                    AmountApplied = "amount_applied",
                    DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                    Reason = "reason",
                },
            ],
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditNoteNumber = "credit_note_number";
        string expectedCreditNotePdf = "credit_note_pdf";
        CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        string expectedInvoiceID = "invoice_id";
        List<SharedCreditNoteLineItem> expectedLineItems =
        [
            new()
            {
                ID = "id",
                Amount = "amount",
                ItemID = "item_id",
                Name = "name",
                Quantity = 0,
                Subtotal = "subtotal",
                TaxAmounts =
                [
                    new()
                    {
                        Amount = "amount",
                        TaxRateDescription = "tax_rate_description",
                        TaxRatePercentage = "tax_rate_percentage",
                    },
                ],
                Discounts =
                [
                    new()
                    {
                        ID = "id",
                        AmountApplied = "amount_applied",
                        AppliesToPriceIDs = ["string"],
                        DiscountType = DiscountDiscountType.Percentage,
                        PercentageDiscount = 0,
                        AmountDiscount = "amount_discount",
                        Reason = "reason",
                    },
                ],
                EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        MaximumAmountAdjustment expectedMaximumAmountAdjustment = new()
        {
            AmountApplied = "amount_applied",
            DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };
        string expectedMemo = "memo";
        string expectedMinimumAmountRefunded = "minimum_amount_refunded";
        ApiEnum<string, Reason> expectedReason = Reason.Duplicate;
        string expectedSubtotal = "subtotal";
        string expectedTotal = "total";
        ApiEnum<string, SharedCreditNoteType> expectedType = SharedCreditNoteType.Refund;
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<SharedCreditNoteDiscount> expectedDiscounts =
        [
            new()
            {
                AmountApplied = "amount_applied",
                DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
                PercentageDiscount = 0,
                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                Reason = "reason",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditNoteNumber, model.CreditNoteNumber);
        Assert.Equal(expectedCreditNotePdf, model.CreditNotePdf);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.Equal(expectedLineItems.Count, model.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], model.LineItems[i]);
        }
        Assert.Equal(expectedMaximumAmountAdjustment, model.MaximumAmountAdjustment);
        Assert.Equal(expectedMemo, model.Memo);
        Assert.Equal(expectedMinimumAmountRefunded, model.MinimumAmountRefunded);
        Assert.Equal(expectedReason, model.Reason);
        Assert.Equal(expectedSubtotal, model.Subtotal);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedVoidedAt, model.VoidedAt);
        Assert.NotNull(model.Discounts);
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SharedCreditNote
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditNoteNumber = "credit_note_number",
            CreditNotePdf = "credit_note_pdf",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceID = "invoice_id",
            LineItems =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    ItemID = "item_id",
                    Name = "name",
                    Quantity = 0,
                    Subtotal = "subtotal",
                    TaxAmounts =
                    [
                        new()
                        {
                            Amount = "amount",
                            TaxRateDescription = "tax_rate_description",
                            TaxRatePercentage = "tax_rate_percentage",
                        },
                    ],
                    Discounts =
                    [
                        new()
                        {
                            ID = "id",
                            AmountApplied = "amount_applied",
                            AppliesToPriceIDs = ["string"],
                            DiscountType = DiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AmountDiscount = "amount_discount",
                            Reason = "reason",
                        },
                    ],
                    EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MaximumAmountAdjustment = new()
            {
                AmountApplied = "amount_applied",
                DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
                PercentageDiscount = 0,
                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                Reason = "reason",
            },
            Memo = "memo",
            MinimumAmountRefunded = "minimum_amount_refunded",
            Reason = Reason.Duplicate,
            Subtotal = "subtotal",
            Total = "total",
            Type = SharedCreditNoteType.Refund,
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Discounts =
            [
                new()
                {
                    AmountApplied = "amount_applied",
                    DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                    Reason = "reason",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedCreditNote>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SharedCreditNote
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditNoteNumber = "credit_note_number",
            CreditNotePdf = "credit_note_pdf",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceID = "invoice_id",
            LineItems =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    ItemID = "item_id",
                    Name = "name",
                    Quantity = 0,
                    Subtotal = "subtotal",
                    TaxAmounts =
                    [
                        new()
                        {
                            Amount = "amount",
                            TaxRateDescription = "tax_rate_description",
                            TaxRatePercentage = "tax_rate_percentage",
                        },
                    ],
                    Discounts =
                    [
                        new()
                        {
                            ID = "id",
                            AmountApplied = "amount_applied",
                            AppliesToPriceIDs = ["string"],
                            DiscountType = DiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AmountDiscount = "amount_discount",
                            Reason = "reason",
                        },
                    ],
                    EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MaximumAmountAdjustment = new()
            {
                AmountApplied = "amount_applied",
                DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
                PercentageDiscount = 0,
                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                Reason = "reason",
            },
            Memo = "memo",
            MinimumAmountRefunded = "minimum_amount_refunded",
            Reason = Reason.Duplicate,
            Subtotal = "subtotal",
            Total = "total",
            Type = SharedCreditNoteType.Refund,
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Discounts =
            [
                new()
                {
                    AmountApplied = "amount_applied",
                    DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                    Reason = "reason",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedCreditNote>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCreditNoteNumber = "credit_note_number";
        string expectedCreditNotePdf = "credit_note_pdf";
        CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        string expectedInvoiceID = "invoice_id";
        List<SharedCreditNoteLineItem> expectedLineItems =
        [
            new()
            {
                ID = "id",
                Amount = "amount",
                ItemID = "item_id",
                Name = "name",
                Quantity = 0,
                Subtotal = "subtotal",
                TaxAmounts =
                [
                    new()
                    {
                        Amount = "amount",
                        TaxRateDescription = "tax_rate_description",
                        TaxRatePercentage = "tax_rate_percentage",
                    },
                ],
                Discounts =
                [
                    new()
                    {
                        ID = "id",
                        AmountApplied = "amount_applied",
                        AppliesToPriceIDs = ["string"],
                        DiscountType = DiscountDiscountType.Percentage,
                        PercentageDiscount = 0,
                        AmountDiscount = "amount_discount",
                        Reason = "reason",
                    },
                ],
                EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        MaximumAmountAdjustment expectedMaximumAmountAdjustment = new()
        {
            AmountApplied = "amount_applied",
            DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };
        string expectedMemo = "memo";
        string expectedMinimumAmountRefunded = "minimum_amount_refunded";
        ApiEnum<string, Reason> expectedReason = Reason.Duplicate;
        string expectedSubtotal = "subtotal";
        string expectedTotal = "total";
        ApiEnum<string, SharedCreditNoteType> expectedType = SharedCreditNoteType.Refund;
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<SharedCreditNoteDiscount> expectedDiscounts =
        [
            new()
            {
                AmountApplied = "amount_applied",
                DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
                PercentageDiscount = 0,
                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                Reason = "reason",
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCreditNoteNumber, deserialized.CreditNoteNumber);
        Assert.Equal(expectedCreditNotePdf, deserialized.CreditNotePdf);
        Assert.Equal(expectedCustomer, deserialized.Customer);
        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.Equal(expectedLineItems.Count, deserialized.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], deserialized.LineItems[i]);
        }
        Assert.Equal(expectedMaximumAmountAdjustment, deserialized.MaximumAmountAdjustment);
        Assert.Equal(expectedMemo, deserialized.Memo);
        Assert.Equal(expectedMinimumAmountRefunded, deserialized.MinimumAmountRefunded);
        Assert.Equal(expectedReason, deserialized.Reason);
        Assert.Equal(expectedSubtotal, deserialized.Subtotal);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedVoidedAt, deserialized.VoidedAt);
        Assert.NotNull(deserialized.Discounts);
        Assert.Equal(expectedDiscounts.Count, deserialized.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], deserialized.Discounts[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SharedCreditNote
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditNoteNumber = "credit_note_number",
            CreditNotePdf = "credit_note_pdf",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceID = "invoice_id",
            LineItems =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    ItemID = "item_id",
                    Name = "name",
                    Quantity = 0,
                    Subtotal = "subtotal",
                    TaxAmounts =
                    [
                        new()
                        {
                            Amount = "amount",
                            TaxRateDescription = "tax_rate_description",
                            TaxRatePercentage = "tax_rate_percentage",
                        },
                    ],
                    Discounts =
                    [
                        new()
                        {
                            ID = "id",
                            AmountApplied = "amount_applied",
                            AppliesToPriceIDs = ["string"],
                            DiscountType = DiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AmountDiscount = "amount_discount",
                            Reason = "reason",
                        },
                    ],
                    EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MaximumAmountAdjustment = new()
            {
                AmountApplied = "amount_applied",
                DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
                PercentageDiscount = 0,
                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                Reason = "reason",
            },
            Memo = "memo",
            MinimumAmountRefunded = "minimum_amount_refunded",
            Reason = Reason.Duplicate,
            Subtotal = "subtotal",
            Total = "total",
            Type = SharedCreditNoteType.Refund,
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Discounts =
            [
                new()
                {
                    AmountApplied = "amount_applied",
                    DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                    Reason = "reason",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SharedCreditNote
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditNoteNumber = "credit_note_number",
            CreditNotePdf = "credit_note_pdf",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceID = "invoice_id",
            LineItems =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    ItemID = "item_id",
                    Name = "name",
                    Quantity = 0,
                    Subtotal = "subtotal",
                    TaxAmounts =
                    [
                        new()
                        {
                            Amount = "amount",
                            TaxRateDescription = "tax_rate_description",
                            TaxRatePercentage = "tax_rate_percentage",
                        },
                    ],
                    Discounts =
                    [
                        new()
                        {
                            ID = "id",
                            AmountApplied = "amount_applied",
                            AppliesToPriceIDs = ["string"],
                            DiscountType = DiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AmountDiscount = "amount_discount",
                            Reason = "reason",
                        },
                    ],
                    EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MaximumAmountAdjustment = new()
            {
                AmountApplied = "amount_applied",
                DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
                PercentageDiscount = 0,
                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                Reason = "reason",
            },
            Memo = "memo",
            MinimumAmountRefunded = "minimum_amount_refunded",
            Reason = Reason.Duplicate,
            Subtotal = "subtotal",
            Total = "total",
            Type = SharedCreditNoteType.Refund,
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SharedCreditNote
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditNoteNumber = "credit_note_number",
            CreditNotePdf = "credit_note_pdf",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceID = "invoice_id",
            LineItems =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    ItemID = "item_id",
                    Name = "name",
                    Quantity = 0,
                    Subtotal = "subtotal",
                    TaxAmounts =
                    [
                        new()
                        {
                            Amount = "amount",
                            TaxRateDescription = "tax_rate_description",
                            TaxRatePercentage = "tax_rate_percentage",
                        },
                    ],
                    Discounts =
                    [
                        new()
                        {
                            ID = "id",
                            AmountApplied = "amount_applied",
                            AppliesToPriceIDs = ["string"],
                            DiscountType = DiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AmountDiscount = "amount_discount",
                            Reason = "reason",
                        },
                    ],
                    EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MaximumAmountAdjustment = new()
            {
                AmountApplied = "amount_applied",
                DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
                PercentageDiscount = 0,
                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                Reason = "reason",
            },
            Memo = "memo",
            MinimumAmountRefunded = "minimum_amount_refunded",
            Reason = Reason.Duplicate,
            Subtotal = "subtotal",
            Total = "total",
            Type = SharedCreditNoteType.Refund,
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SharedCreditNote
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditNoteNumber = "credit_note_number",
            CreditNotePdf = "credit_note_pdf",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceID = "invoice_id",
            LineItems =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    ItemID = "item_id",
                    Name = "name",
                    Quantity = 0,
                    Subtotal = "subtotal",
                    TaxAmounts =
                    [
                        new()
                        {
                            Amount = "amount",
                            TaxRateDescription = "tax_rate_description",
                            TaxRatePercentage = "tax_rate_percentage",
                        },
                    ],
                    Discounts =
                    [
                        new()
                        {
                            ID = "id",
                            AmountApplied = "amount_applied",
                            AppliesToPriceIDs = ["string"],
                            DiscountType = DiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AmountDiscount = "amount_discount",
                            Reason = "reason",
                        },
                    ],
                    EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MaximumAmountAdjustment = new()
            {
                AmountApplied = "amount_applied",
                DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
                PercentageDiscount = 0,
                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                Reason = "reason",
            },
            Memo = "memo",
            MinimumAmountRefunded = "minimum_amount_refunded",
            Reason = Reason.Duplicate,
            Subtotal = "subtotal",
            Total = "total",
            Type = SharedCreditNoteType.Refund,
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Discounts = null,
        };

        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SharedCreditNote
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditNoteNumber = "credit_note_number",
            CreditNotePdf = "credit_note_pdf",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            InvoiceID = "invoice_id",
            LineItems =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    ItemID = "item_id",
                    Name = "name",
                    Quantity = 0,
                    Subtotal = "subtotal",
                    TaxAmounts =
                    [
                        new()
                        {
                            Amount = "amount",
                            TaxRateDescription = "tax_rate_description",
                            TaxRatePercentage = "tax_rate_percentage",
                        },
                    ],
                    Discounts =
                    [
                        new()
                        {
                            ID = "id",
                            AmountApplied = "amount_applied",
                            AppliesToPriceIDs = ["string"],
                            DiscountType = DiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AmountDiscount = "amount_discount",
                            Reason = "reason",
                        },
                    ],
                    EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            MaximumAmountAdjustment = new()
            {
                AmountApplied = "amount_applied",
                DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
                PercentageDiscount = 0,
                AppliesToPrices = [new() { ID = "id", Name = "name" }],
                Reason = "reason",
            },
            Memo = "memo",
            MinimumAmountRefunded = "minimum_amount_refunded",
            Reason = Reason.Duplicate,
            Subtotal = "subtotal",
            Total = "total",
            Type = SharedCreditNoteType.Refund,
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Discounts = null,
        };

        model.Validate();
    }
}

public class SharedCreditNoteLineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            Discounts =
            [
                new()
                {
                    ID = "id",
                    AmountApplied = "amount_applied",
                    AppliesToPriceIDs = ["string"],
                    DiscountType = DiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AmountDiscount = "amount_discount",
                    Reason = "reason",
                },
            ],
            EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedItemID = "item_id";
        string expectedName = "name";
        double expectedQuantity = 0;
        string expectedSubtotal = "subtotal";
        List<TaxAmount> expectedTaxAmounts =
        [
            new()
            {
                Amount = "amount",
                TaxRateDescription = "tax_rate_description",
                TaxRatePercentage = "tax_rate_percentage",
            },
        ];
        List<Discount> expectedDiscounts =
        [
            new()
            {
                ID = "id",
                AmountApplied = "amount_applied",
                AppliesToPriceIDs = ["string"],
                DiscountType = DiscountDiscountType.Percentage,
                PercentageDiscount = 0,
                AmountDiscount = "amount_discount",
                Reason = "reason",
            },
        ];
        DateTimeOffset expectedEndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartTimeInclusive = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedItemID, model.ItemID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedSubtotal, model.Subtotal);
        Assert.Equal(expectedTaxAmounts.Count, model.TaxAmounts.Count);
        for (int i = 0; i < expectedTaxAmounts.Count; i++)
        {
            Assert.Equal(expectedTaxAmounts[i], model.TaxAmounts[i]);
        }
        Assert.NotNull(model.Discounts);
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
        Assert.Equal(expectedEndTimeExclusive, model.EndTimeExclusive);
        Assert.Equal(expectedStartTimeInclusive, model.StartTimeInclusive);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            Discounts =
            [
                new()
                {
                    ID = "id",
                    AmountApplied = "amount_applied",
                    AppliesToPriceIDs = ["string"],
                    DiscountType = DiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AmountDiscount = "amount_discount",
                    Reason = "reason",
                },
            ],
            EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedCreditNoteLineItem>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            Discounts =
            [
                new()
                {
                    ID = "id",
                    AmountApplied = "amount_applied",
                    AppliesToPriceIDs = ["string"],
                    DiscountType = DiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AmountDiscount = "amount_discount",
                    Reason = "reason",
                },
            ],
            EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedCreditNoteLineItem>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedItemID = "item_id";
        string expectedName = "name";
        double expectedQuantity = 0;
        string expectedSubtotal = "subtotal";
        List<TaxAmount> expectedTaxAmounts =
        [
            new()
            {
                Amount = "amount",
                TaxRateDescription = "tax_rate_description",
                TaxRatePercentage = "tax_rate_percentage",
            },
        ];
        List<Discount> expectedDiscounts =
        [
            new()
            {
                ID = "id",
                AmountApplied = "amount_applied",
                AppliesToPriceIDs = ["string"],
                DiscountType = DiscountDiscountType.Percentage,
                PercentageDiscount = 0,
                AmountDiscount = "amount_discount",
                Reason = "reason",
            },
        ];
        DateTimeOffset expectedEndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStartTimeInclusive = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedItemID, deserialized.ItemID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedSubtotal, deserialized.Subtotal);
        Assert.Equal(expectedTaxAmounts.Count, deserialized.TaxAmounts.Count);
        for (int i = 0; i < expectedTaxAmounts.Count; i++)
        {
            Assert.Equal(expectedTaxAmounts[i], deserialized.TaxAmounts[i]);
        }
        Assert.NotNull(deserialized.Discounts);
        Assert.Equal(expectedDiscounts.Count, deserialized.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], deserialized.Discounts[i]);
        }
        Assert.Equal(expectedEndTimeExclusive, deserialized.EndTimeExclusive);
        Assert.Equal(expectedStartTimeInclusive, deserialized.StartTimeInclusive);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            Discounts =
            [
                new()
                {
                    ID = "id",
                    AmountApplied = "amount_applied",
                    AppliesToPriceIDs = ["string"],
                    DiscountType = DiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AmountDiscount = "amount_discount",
                    Reason = "reason",
                },
            ],
            EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Discounts = null,
        };

        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            EndTimeExclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartTimeInclusive = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Discounts = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            Discounts =
            [
                new()
                {
                    ID = "id",
                    AmountApplied = "amount_applied",
                    AppliesToPriceIDs = ["string"],
                    DiscountType = DiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AmountDiscount = "amount_discount",
                    Reason = "reason",
                },
            ],
        };

        Assert.Null(model.EndTimeExclusive);
        Assert.False(model.RawData.ContainsKey("end_time_exclusive"));
        Assert.Null(model.StartTimeInclusive);
        Assert.False(model.RawData.ContainsKey("start_time_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            Discounts =
            [
                new()
                {
                    ID = "id",
                    AmountApplied = "amount_applied",
                    AppliesToPriceIDs = ["string"],
                    DiscountType = DiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AmountDiscount = "amount_discount",
                    Reason = "reason",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            Discounts =
            [
                new()
                {
                    ID = "id",
                    AmountApplied = "amount_applied",
                    AppliesToPriceIDs = ["string"],
                    DiscountType = DiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AmountDiscount = "amount_discount",
                    Reason = "reason",
                },
            ],

            EndTimeExclusive = null,
            StartTimeInclusive = null,
        };

        Assert.Null(model.EndTimeExclusive);
        Assert.True(model.RawData.ContainsKey("end_time_exclusive"));
        Assert.Null(model.StartTimeInclusive);
        Assert.True(model.RawData.ContainsKey("start_time_inclusive"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SharedCreditNoteLineItem
        {
            ID = "id",
            Amount = "amount",
            ItemID = "item_id",
            Name = "name",
            Quantity = 0,
            Subtotal = "subtotal",
            TaxAmounts =
            [
                new()
                {
                    Amount = "amount",
                    TaxRateDescription = "tax_rate_description",
                    TaxRatePercentage = "tax_rate_percentage",
                },
            ],
            Discounts =
            [
                new()
                {
                    ID = "id",
                    AmountApplied = "amount_applied",
                    AppliesToPriceIDs = ["string"],
                    DiscountType = DiscountDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AmountDiscount = "amount_discount",
                    Reason = "reason",
                },
            ],

            EndTimeExclusive = null,
            StartTimeInclusive = null,
        };

        model.Validate();
    }
}

public class DiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Discount
        {
            ID = "id",
            AmountApplied = "amount_applied",
            AppliesToPriceIDs = ["string"],
            DiscountType = DiscountDiscountType.Percentage,
            PercentageDiscount = 0,
            AmountDiscount = "amount_discount",
            Reason = "reason",
        };

        string expectedID = "id";
        string expectedAmountApplied = "amount_applied";
        List<string> expectedAppliesToPriceIDs = ["string"];
        ApiEnum<string, DiscountDiscountType> expectedDiscountType =
            DiscountDiscountType.Percentage;
        double expectedPercentageDiscount = 0;
        string expectedAmountDiscount = "amount_discount";
        string expectedReason = "reason";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmountApplied, model.AmountApplied);
        Assert.Equal(expectedAppliesToPriceIDs.Count, model.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], model.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedAmountDiscount, model.AmountDiscount);
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Discount
        {
            ID = "id",
            AmountApplied = "amount_applied",
            AppliesToPriceIDs = ["string"],
            DiscountType = DiscountDiscountType.Percentage,
            PercentageDiscount = 0,
            AmountDiscount = "amount_discount",
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Discount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Discount
        {
            ID = "id",
            AmountApplied = "amount_applied",
            AppliesToPriceIDs = ["string"],
            DiscountType = DiscountDiscountType.Percentage,
            PercentageDiscount = 0,
            AmountDiscount = "amount_discount",
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Discount>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedAmountApplied = "amount_applied";
        List<string> expectedAppliesToPriceIDs = ["string"];
        ApiEnum<string, DiscountDiscountType> expectedDiscountType =
            DiscountDiscountType.Percentage;
        double expectedPercentageDiscount = 0;
        string expectedAmountDiscount = "amount_discount";
        string expectedReason = "reason";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmountApplied, deserialized.AmountApplied);
        Assert.Equal(expectedAppliesToPriceIDs.Count, deserialized.AppliesToPriceIDs.Count);
        for (int i = 0; i < expectedAppliesToPriceIDs.Count; i++)
        {
            Assert.Equal(expectedAppliesToPriceIDs[i], deserialized.AppliesToPriceIDs[i]);
        }
        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
        Assert.Equal(expectedAmountDiscount, deserialized.AmountDiscount);
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Discount
        {
            ID = "id",
            AmountApplied = "amount_applied",
            AppliesToPriceIDs = ["string"],
            DiscountType = DiscountDiscountType.Percentage,
            PercentageDiscount = 0,
            AmountDiscount = "amount_discount",
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Discount
        {
            ID = "id",
            AmountApplied = "amount_applied",
            AppliesToPriceIDs = ["string"],
            DiscountType = DiscountDiscountType.Percentage,
            PercentageDiscount = 0,
        };

        Assert.Null(model.AmountDiscount);
        Assert.False(model.RawData.ContainsKey("amount_discount"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Discount
        {
            ID = "id",
            AmountApplied = "amount_applied",
            AppliesToPriceIDs = ["string"],
            DiscountType = DiscountDiscountType.Percentage,
            PercentageDiscount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Discount
        {
            ID = "id",
            AmountApplied = "amount_applied",
            AppliesToPriceIDs = ["string"],
            DiscountType = DiscountDiscountType.Percentage,
            PercentageDiscount = 0,

            AmountDiscount = null,
            Reason = null,
        };

        Assert.Null(model.AmountDiscount);
        Assert.True(model.RawData.ContainsKey("amount_discount"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Discount
        {
            ID = "id",
            AmountApplied = "amount_applied",
            AppliesToPriceIDs = ["string"],
            DiscountType = DiscountDiscountType.Percentage,
            PercentageDiscount = 0,

            AmountDiscount = null,
            Reason = null,
        };

        model.Validate();
    }
}

public class DiscountDiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(DiscountDiscountType.Percentage)]
    [InlineData(DiscountDiscountType.Amount)]
    public void Validation_Works(DiscountDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountDiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DiscountDiscountType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DiscountDiscountType.Percentage)]
    [InlineData(DiscountDiscountType.Amount)]
    public void SerializationRoundtrip_Works(DiscountDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DiscountDiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DiscountDiscountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DiscountDiscountType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DiscountDiscountType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MaximumAmountAdjustmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MaximumAmountAdjustment
        {
            AmountApplied = "amount_applied",
            DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };

        string expectedAmountApplied = "amount_applied";
        ApiEnum<string, MaximumAmountAdjustmentDiscountType> expectedDiscountType =
            MaximumAmountAdjustmentDiscountType.Percentage;
        double expectedPercentageDiscount = 0;
        List<AppliesToPrice> expectedAppliesToPrices = [new() { ID = "id", Name = "name" }];
        string expectedReason = "reason";

        Assert.Equal(expectedAmountApplied, model.AmountApplied);
        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.NotNull(model.AppliesToPrices);
        Assert.Equal(expectedAppliesToPrices.Count, model.AppliesToPrices.Count);
        for (int i = 0; i < expectedAppliesToPrices.Count; i++)
        {
            Assert.Equal(expectedAppliesToPrices[i], model.AppliesToPrices[i]);
        }
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MaximumAmountAdjustment
        {
            AmountApplied = "amount_applied",
            DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MaximumAmountAdjustment>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MaximumAmountAdjustment
        {
            AmountApplied = "amount_applied",
            DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MaximumAmountAdjustment>(json);
        Assert.NotNull(deserialized);

        string expectedAmountApplied = "amount_applied";
        ApiEnum<string, MaximumAmountAdjustmentDiscountType> expectedDiscountType =
            MaximumAmountAdjustmentDiscountType.Percentage;
        double expectedPercentageDiscount = 0;
        List<AppliesToPrice> expectedAppliesToPrices = [new() { ID = "id", Name = "name" }];
        string expectedReason = "reason";

        Assert.Equal(expectedAmountApplied, deserialized.AmountApplied);
        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
        Assert.NotNull(deserialized.AppliesToPrices);
        Assert.Equal(expectedAppliesToPrices.Count, deserialized.AppliesToPrices.Count);
        for (int i = 0; i < expectedAppliesToPrices.Count; i++)
        {
            Assert.Equal(expectedAppliesToPrices[i], deserialized.AppliesToPrices[i]);
        }
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MaximumAmountAdjustment
        {
            AmountApplied = "amount_applied",
            DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MaximumAmountAdjustment
        {
            AmountApplied = "amount_applied",
            DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
            PercentageDiscount = 0,
        };

        Assert.Null(model.AppliesToPrices);
        Assert.False(model.RawData.ContainsKey("applies_to_prices"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MaximumAmountAdjustment
        {
            AmountApplied = "amount_applied",
            DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
            PercentageDiscount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MaximumAmountAdjustment
        {
            AmountApplied = "amount_applied",
            DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
            PercentageDiscount = 0,

            AppliesToPrices = null,
            Reason = null,
        };

        Assert.Null(model.AppliesToPrices);
        Assert.True(model.RawData.ContainsKey("applies_to_prices"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MaximumAmountAdjustment
        {
            AmountApplied = "amount_applied",
            DiscountType = MaximumAmountAdjustmentDiscountType.Percentage,
            PercentageDiscount = 0,

            AppliesToPrices = null,
            Reason = null,
        };

        model.Validate();
    }
}

public class MaximumAmountAdjustmentDiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(MaximumAmountAdjustmentDiscountType.Percentage)]
    public void Validation_Works(MaximumAmountAdjustmentDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MaximumAmountAdjustmentDiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MaximumAmountAdjustmentDiscountType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MaximumAmountAdjustmentDiscountType.Percentage)]
    public void SerializationRoundtrip_Works(MaximumAmountAdjustmentDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MaximumAmountAdjustmentDiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MaximumAmountAdjustmentDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, MaximumAmountAdjustmentDiscountType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, MaximumAmountAdjustmentDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AppliesToPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AppliesToPrice { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AppliesToPrice { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AppliesToPrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AppliesToPrice { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AppliesToPrice>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AppliesToPrice { ID = "id", Name = "name" };

        model.Validate();
    }
}

public class ReasonTest : TestBase
{
    [Theory]
    [InlineData(Reason.Duplicate)]
    [InlineData(Reason.Fraudulent)]
    [InlineData(Reason.OrderChange)]
    [InlineData(Reason.ProductUnsatisfactory)]
    public void Validation_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Reason.Duplicate)]
    [InlineData(Reason.Fraudulent)]
    [InlineData(Reason.OrderChange)]
    [InlineData(Reason.ProductUnsatisfactory)]
    public void SerializationRoundtrip_Works(Reason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Reason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Reason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SharedCreditNoteTypeTest : TestBase
{
    [Theory]
    [InlineData(SharedCreditNoteType.Refund)]
    [InlineData(SharedCreditNoteType.Adjustment)]
    public void Validation_Works(SharedCreditNoteType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SharedCreditNoteType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SharedCreditNoteType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SharedCreditNoteType.Refund)]
    [InlineData(SharedCreditNoteType.Adjustment)]
    public void SerializationRoundtrip_Works(SharedCreditNoteType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SharedCreditNoteType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SharedCreditNoteType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SharedCreditNoteType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SharedCreditNoteType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SharedCreditNoteDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedCreditNoteDiscount
        {
            AmountApplied = "amount_applied",
            DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };

        string expectedAmountApplied = "amount_applied";
        ApiEnum<string, SharedCreditNoteDiscountDiscountType> expectedDiscountType =
            SharedCreditNoteDiscountDiscountType.Percentage;
        double expectedPercentageDiscount = 0;
        List<SharedCreditNoteDiscountAppliesToPrice> expectedAppliesToPrices =
        [
            new() { ID = "id", Name = "name" },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedAmountApplied, model.AmountApplied);
        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.NotNull(model.AppliesToPrices);
        Assert.Equal(expectedAppliesToPrices.Count, model.AppliesToPrices.Count);
        for (int i = 0; i < expectedAppliesToPrices.Count; i++)
        {
            Assert.Equal(expectedAppliesToPrices[i], model.AppliesToPrices[i]);
        }
        Assert.Equal(expectedReason, model.Reason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SharedCreditNoteDiscount
        {
            AmountApplied = "amount_applied",
            DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedCreditNoteDiscount>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SharedCreditNoteDiscount
        {
            AmountApplied = "amount_applied",
            DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedCreditNoteDiscount>(json);
        Assert.NotNull(deserialized);

        string expectedAmountApplied = "amount_applied";
        ApiEnum<string, SharedCreditNoteDiscountDiscountType> expectedDiscountType =
            SharedCreditNoteDiscountDiscountType.Percentage;
        double expectedPercentageDiscount = 0;
        List<SharedCreditNoteDiscountAppliesToPrice> expectedAppliesToPrices =
        [
            new() { ID = "id", Name = "name" },
        ];
        string expectedReason = "reason";

        Assert.Equal(expectedAmountApplied, deserialized.AmountApplied);
        Assert.Equal(expectedDiscountType, deserialized.DiscountType);
        Assert.Equal(expectedPercentageDiscount, deserialized.PercentageDiscount);
        Assert.NotNull(deserialized.AppliesToPrices);
        Assert.Equal(expectedAppliesToPrices.Count, deserialized.AppliesToPrices.Count);
        for (int i = 0; i < expectedAppliesToPrices.Count; i++)
        {
            Assert.Equal(expectedAppliesToPrices[i], deserialized.AppliesToPrices[i]);
        }
        Assert.Equal(expectedReason, deserialized.Reason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SharedCreditNoteDiscount
        {
            AmountApplied = "amount_applied",
            DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SharedCreditNoteDiscount
        {
            AmountApplied = "amount_applied",
            DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
            PercentageDiscount = 0,
        };

        Assert.Null(model.AppliesToPrices);
        Assert.False(model.RawData.ContainsKey("applies_to_prices"));
        Assert.Null(model.Reason);
        Assert.False(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SharedCreditNoteDiscount
        {
            AmountApplied = "amount_applied",
            DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
            PercentageDiscount = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SharedCreditNoteDiscount
        {
            AmountApplied = "amount_applied",
            DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
            PercentageDiscount = 0,

            AppliesToPrices = null,
            Reason = null,
        };

        Assert.Null(model.AppliesToPrices);
        Assert.True(model.RawData.ContainsKey("applies_to_prices"));
        Assert.Null(model.Reason);
        Assert.True(model.RawData.ContainsKey("reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SharedCreditNoteDiscount
        {
            AmountApplied = "amount_applied",
            DiscountType = SharedCreditNoteDiscountDiscountType.Percentage,
            PercentageDiscount = 0,

            AppliesToPrices = null,
            Reason = null,
        };

        model.Validate();
    }
}

public class SharedCreditNoteDiscountDiscountTypeTest : TestBase
{
    [Theory]
    [InlineData(SharedCreditNoteDiscountDiscountType.Percentage)]
    public void Validation_Works(SharedCreditNoteDiscountDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SharedCreditNoteDiscountDiscountType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SharedCreditNoteDiscountDiscountType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<OrbInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SharedCreditNoteDiscountDiscountType.Percentage)]
    public void SerializationRoundtrip_Works(SharedCreditNoteDiscountDiscountType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SharedCreditNoteDiscountDiscountType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SharedCreditNoteDiscountDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SharedCreditNoteDiscountDiscountType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SharedCreditNoteDiscountDiscountType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SharedCreditNoteDiscountAppliesToPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SharedCreditNoteDiscountAppliesToPrice { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SharedCreditNoteDiscountAppliesToPrice { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedCreditNoteDiscountAppliesToPrice>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SharedCreditNoteDiscountAppliesToPrice { ID = "id", Name = "name" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SharedCreditNoteDiscountAppliesToPrice>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SharedCreditNoteDiscountAppliesToPrice { ID = "id", Name = "name" };

        model.Validate();
    }
}
