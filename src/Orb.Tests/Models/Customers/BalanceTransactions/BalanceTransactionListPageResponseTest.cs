using System;
using System.Collections.Generic;
using Orb.Core;
using Orb.Models;
using Orb.Models.Customers.BalanceTransactions;

namespace Orb.Tests.Models.Customers.BalanceTransactions;

public class BalanceTransactionListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "cgZa3SXcsPTVyC4Y",
                    Action = DataAction.AppliedToInvoice,
                    Amount = "11.00",
                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                    CreditNote = new("id"),
                    Description = "An optional description",
                    EndingBalance = "22.00",
                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                    StartingBalance = "33.00",
                    Type = DataType.Increment,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<Data> expectedData =
        [
            new()
            {
                ID = "cgZa3SXcsPTVyC4Y",
                Action = DataAction.AppliedToInvoice,
                Amount = "11.00",
                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                CreditNote = new("id"),
                Description = "An optional description",
                EndingBalance = "22.00",
                Invoice = new("gXcsPTVyC4YZa3Sc"),
                StartingBalance = "33.00",
                Type = DataType.Increment,
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
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
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = DataAction.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = DataType.Increment,
        };

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, DataAction> expectedAction = DataAction.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, DataType> expectedType = DataType.Increment;

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
