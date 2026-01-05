using System;
using System.Collections.Generic;
using System.Text.Json;
using Orb.Models.CreditNotes;
using Models = Orb.Models;

namespace Orb.Tests.Models.CreditNotes;

public class CreditNoteListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditNoteListPageResponse
        {
            Data =
            [
                new()
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
                                    AppliesToPriceIds = ["string"],
                                    DiscountType = Models::DiscountDiscountType.Percentage,
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
                        DiscountType = Models::MaximumAmountAdjustmentDiscountType.Percentage,
                        PercentageDiscount = 0,
                        AppliesToPrices = [new() { ID = "id", Name = "name" }],
                        Reason = "reason",
                    },
                    Memo = "memo",
                    MinimumAmountRefunded = "minimum_amount_refunded",
                    Reason = Models::Reason.Duplicate,
                    Subtotal = "subtotal",
                    Total = "total",
                    Type = Models::SharedCreditNoteType.Refund,
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Discounts =
                    [
                        new()
                        {
                            AmountApplied = "amount_applied",
                            DiscountType = Models::SharedCreditNoteDiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AppliesToPrices = [new() { ID = "id", Name = "name" }],
                            Reason = "reason",
                        },
                    ],
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Models::SharedCreditNote> expectedData =
        [
            new()
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
                                AppliesToPriceIds = ["string"],
                                DiscountType = Models::DiscountDiscountType.Percentage,
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
                    DiscountType = Models::MaximumAmountAdjustmentDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                    Reason = "reason",
                },
                Memo = "memo",
                MinimumAmountRefunded = "minimum_amount_refunded",
                Reason = Models::Reason.Duplicate,
                Subtotal = "subtotal",
                Total = "total",
                Type = Models::SharedCreditNoteType.Refund,
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Discounts =
                [
                    new()
                    {
                        AmountApplied = "amount_applied",
                        DiscountType = Models::SharedCreditNoteDiscountDiscountType.Percentage,
                        PercentageDiscount = 0,
                        AppliesToPrices = [new() { ID = "id", Name = "name" }],
                        Reason = "reason",
                    },
                ],
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
        var model = new CreditNoteListPageResponse
        {
            Data =
            [
                new()
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
                                    AppliesToPriceIds = ["string"],
                                    DiscountType = Models::DiscountDiscountType.Percentage,
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
                        DiscountType = Models::MaximumAmountAdjustmentDiscountType.Percentage,
                        PercentageDiscount = 0,
                        AppliesToPrices = [new() { ID = "id", Name = "name" }],
                        Reason = "reason",
                    },
                    Memo = "memo",
                    MinimumAmountRefunded = "minimum_amount_refunded",
                    Reason = Models::Reason.Duplicate,
                    Subtotal = "subtotal",
                    Total = "total",
                    Type = Models::SharedCreditNoteType.Refund,
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Discounts =
                    [
                        new()
                        {
                            AmountApplied = "amount_applied",
                            DiscountType = Models::SharedCreditNoteDiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AppliesToPrices = [new() { ID = "id", Name = "name" }],
                            Reason = "reason",
                        },
                    ],
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditNoteListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditNoteListPageResponse
        {
            Data =
            [
                new()
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
                                    AppliesToPriceIds = ["string"],
                                    DiscountType = Models::DiscountDiscountType.Percentage,
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
                        DiscountType = Models::MaximumAmountAdjustmentDiscountType.Percentage,
                        PercentageDiscount = 0,
                        AppliesToPrices = [new() { ID = "id", Name = "name" }],
                        Reason = "reason",
                    },
                    Memo = "memo",
                    MinimumAmountRefunded = "minimum_amount_refunded",
                    Reason = Models::Reason.Duplicate,
                    Subtotal = "subtotal",
                    Total = "total",
                    Type = Models::SharedCreditNoteType.Refund,
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Discounts =
                    [
                        new()
                        {
                            AmountApplied = "amount_applied",
                            DiscountType = Models::SharedCreditNoteDiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AppliesToPrices = [new() { ID = "id", Name = "name" }],
                            Reason = "reason",
                        },
                    ],
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<CreditNoteListPageResponse>(element);
        Assert.NotNull(deserialized);

        List<Models::SharedCreditNote> expectedData =
        [
            new()
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
                                AppliesToPriceIds = ["string"],
                                DiscountType = Models::DiscountDiscountType.Percentage,
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
                    DiscountType = Models::MaximumAmountAdjustmentDiscountType.Percentage,
                    PercentageDiscount = 0,
                    AppliesToPrices = [new() { ID = "id", Name = "name" }],
                    Reason = "reason",
                },
                Memo = "memo",
                MinimumAmountRefunded = "minimum_amount_refunded",
                Reason = Models::Reason.Duplicate,
                Subtotal = "subtotal",
                Total = "total",
                Type = Models::SharedCreditNoteType.Refund,
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Discounts =
                [
                    new()
                    {
                        AmountApplied = "amount_applied",
                        DiscountType = Models::SharedCreditNoteDiscountDiscountType.Percentage,
                        PercentageDiscount = 0,
                        AppliesToPrices = [new() { ID = "id", Name = "name" }],
                        Reason = "reason",
                    },
                ],
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
        var model = new CreditNoteListPageResponse
        {
            Data =
            [
                new()
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
                                    AppliesToPriceIds = ["string"],
                                    DiscountType = Models::DiscountDiscountType.Percentage,
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
                        DiscountType = Models::MaximumAmountAdjustmentDiscountType.Percentage,
                        PercentageDiscount = 0,
                        AppliesToPrices = [new() { ID = "id", Name = "name" }],
                        Reason = "reason",
                    },
                    Memo = "memo",
                    MinimumAmountRefunded = "minimum_amount_refunded",
                    Reason = Models::Reason.Duplicate,
                    Subtotal = "subtotal",
                    Total = "total",
                    Type = Models::SharedCreditNoteType.Refund,
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Discounts =
                    [
                        new()
                        {
                            AmountApplied = "amount_applied",
                            DiscountType = Models::SharedCreditNoteDiscountDiscountType.Percentage,
                            PercentageDiscount = 0,
                            AppliesToPrices = [new() { ID = "id", Name = "name" }],
                            Reason = "reason",
                        },
                    ],
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
