using System;
using Orb.Core;
using Orb.Models;
using BalanceTransactions = Orb.Models.Customers.BalanceTransactions;

namespace Orb.Tests.Models.Customers.BalanceTransactions;

public class BalanceTransactionCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BalanceTransactions::BalanceTransactionCreateResponse
        {
            ID = "cgZa3SXcsPTVyC4Y",
            Action = BalanceTransactions::Action.AppliedToInvoice,
            Amount = "11.00",
            CreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00"),
            CreditNote = new("id"),
            Description = "An optional description",
            EndingBalance = "22.00",
            Invoice = new("gXcsPTVyC4YZa3Sc"),
            StartingBalance = "33.00",
            Type = BalanceTransactions::BalanceTransactionCreateResponseType.Increment,
        };

        string expectedID = "cgZa3SXcsPTVyC4Y";
        ApiEnum<string, BalanceTransactions::Action> expectedAction =
            BalanceTransactions::Action.AppliedToInvoice;
        string expectedAmount = "11.00";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2022-05-01T07:01:31+00:00");
        CreditNoteTiny expectedCreditNote = new("id");
        string expectedDescription = "An optional description";
        string expectedEndingBalance = "22.00";
        InvoiceTiny expectedInvoice = new("gXcsPTVyC4YZa3Sc");
        string expectedStartingBalance = "33.00";
        ApiEnum<string, BalanceTransactions::BalanceTransactionCreateResponseType> expectedType =
            BalanceTransactions::BalanceTransactionCreateResponseType.Increment;

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
