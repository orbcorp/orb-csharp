using System;
using System.Collections.Generic;
using Orb.Core;
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
                    DiscountType = DiscountModelDiscountType.Percentage,
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
        List<LineItemModel> expectedLineItems =
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
        List<DiscountModel> expectedDiscounts =
        [
            new()
            {
                AmountApplied = "amount_applied",
                DiscountType = DiscountModelDiscountType.Percentage,
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
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
    }
}

public class LineItemModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LineItemModel
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
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
        Assert.Equal(expectedEndTimeExclusive, model.EndTimeExclusive);
        Assert.Equal(expectedStartTimeInclusive, model.StartTimeInclusive);
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
        Assert.Equal(expectedAppliesToPrices.Count, model.AppliesToPrices.Count);
        for (int i = 0; i < expectedAppliesToPrices.Count; i++)
        {
            Assert.Equal(expectedAppliesToPrices[i], model.AppliesToPrices[i]);
        }
        Assert.Equal(expectedReason, model.Reason);
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
}

public class DiscountModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DiscountModel
        {
            AmountApplied = "amount_applied",
            DiscountType = DiscountModelDiscountType.Percentage,
            PercentageDiscount = 0,
            AppliesToPrices = [new() { ID = "id", Name = "name" }],
            Reason = "reason",
        };

        string expectedAmountApplied = "amount_applied";
        ApiEnum<string, DiscountModelDiscountType> expectedDiscountType =
            DiscountModelDiscountType.Percentage;
        double expectedPercentageDiscount = 0;
        List<AppliesToPriceModel> expectedAppliesToPrices = [new() { ID = "id", Name = "name" }];
        string expectedReason = "reason";

        Assert.Equal(expectedAmountApplied, model.AmountApplied);
        Assert.Equal(expectedDiscountType, model.DiscountType);
        Assert.Equal(expectedPercentageDiscount, model.PercentageDiscount);
        Assert.Equal(expectedAppliesToPrices.Count, model.AppliesToPrices.Count);
        for (int i = 0; i < expectedAppliesToPrices.Count; i++)
        {
            Assert.Equal(expectedAppliesToPrices[i], model.AppliesToPrices[i]);
        }
        Assert.Equal(expectedReason, model.Reason);
    }
}

public class AppliesToPriceModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AppliesToPriceModel { ID = "id", Name = "name" };

        string expectedID = "id";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedName, model.Name);
    }
}
