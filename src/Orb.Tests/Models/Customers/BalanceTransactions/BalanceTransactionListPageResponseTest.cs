using System;
using System.Collections.Generic;
using System.Text.Json;
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
                    Action = BalanceTransactionListResponseAction.AppliedToInvoice,
                    Amount = "11.00",
                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                    CreditNote = new("id"),
                    Description = "An optional description",
                    EndingBalance = "22.00",
                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                    StartingBalance = "33.00",
                    Type = BalanceTransactionListResponseType.Increment,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<BalanceTransactionListResponse> expectedData =
        [
            new()
            {
                ID = "cgZa3SXcsPTVyC4Y",
                Action = BalanceTransactionListResponseAction.AppliedToInvoice,
                Amount = "11.00",
                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                CreditNote = new("id"),
                Description = "An optional description",
                EndingBalance = "22.00",
                Invoice = new("gXcsPTVyC4YZa3Sc"),
                StartingBalance = "33.00",
                Type = BalanceTransactionListResponseType.Increment,
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BalanceTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "cgZa3SXcsPTVyC4Y",
                    Action = BalanceTransactionListResponseAction.AppliedToInvoice,
                    Amount = "11.00",
                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                    CreditNote = new("id"),
                    Description = "An optional description",
                    EndingBalance = "22.00",
                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                    StartingBalance = "33.00",
                    Type = BalanceTransactionListResponseType.Increment,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BalanceTransactionListPageResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BalanceTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "cgZa3SXcsPTVyC4Y",
                    Action = BalanceTransactionListResponseAction.AppliedToInvoice,
                    Amount = "11.00",
                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                    CreditNote = new("id"),
                    Description = "An optional description",
                    EndingBalance = "22.00",
                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                    StartingBalance = "33.00",
                    Type = BalanceTransactionListResponseType.Increment,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BalanceTransactionListPageResponse>(element);
        Assert.NotNull(deserialized);

        List<BalanceTransactionListResponse> expectedData =
        [
            new()
            {
                ID = "cgZa3SXcsPTVyC4Y",
                Action = BalanceTransactionListResponseAction.AppliedToInvoice,
                Amount = "11.00",
                CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                CreditNote = new("id"),
                Description = "An optional description",
                EndingBalance = "22.00",
                Invoice = new("gXcsPTVyC4YZa3Sc"),
                StartingBalance = "33.00",
                Type = BalanceTransactionListResponseType.Increment,
            },
        ];
        PaginationMetadata expectedPaginationMetadata = new()
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
        var model = new BalanceTransactionListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "cgZa3SXcsPTVyC4Y",
                    Action = BalanceTransactionListResponseAction.AppliedToInvoice,
                    Amount = "11.00",
                    CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
                    CreditNote = new("id"),
                    Description = "An optional description",
                    EndingBalance = "22.00",
                    Invoice = new("gXcsPTVyC4YZa3Sc"),
                    StartingBalance = "33.00",
                    Type = BalanceTransactionListResponseType.Increment,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        model.Validate();
    }
}
