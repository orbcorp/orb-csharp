using System;
using System.Collections.Generic;
using Orb.Core;
using Orb.Models.Customers.Credits.Ledger;
using Models = Orb.Models;

namespace Orb.Tests.Models.Customers.Credits.Ledger;

public class VoidInitiatedLedgerEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new VoidInitiatedLedgerEntry
        {
            ID = "id",
            Amount = 0,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreditBlock = new()
            {
                ID = "id",
                ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Filters =
                [
                    new()
                    {
                        Field = Filter1Field.PriceID,
                        Operator = Filter1Operator.Includes,
                        Values = ["string"],
                    },
                ],
                PerUnitCostBasis = "per_unit_cost_basis",
            },
            Currency = "currency",
            Customer = new() { ID = "id", ExternalCustomerID = "external_customer_id" },
            Description = "description",
            EndingBalance = 0,
            EntryStatus = VoidInitiatedLedgerEntryEntryStatus.Committed,
            EntryType = VoidInitiatedLedgerEntryEntryType.VoidInitiated,
            LedgerSequenceNumber = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            NewBlockExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            StartingBalance = 0,
            VoidAmount = 0,
            VoidReason = "void_reason",
        };

        string expectedID = "id";
        double expectedAmount = 0;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        AffectedBlock expectedCreditBlock = new()
        {
            ID = "id",
            ExpiryDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Filters =
            [
                new()
                {
                    Field = Filter1Field.PriceID,
                    Operator = Filter1Operator.Includes,
                    Values = ["string"],
                },
            ],
            PerUnitCostBasis = "per_unit_cost_basis",
        };
        string expectedCurrency = "currency";
        Models::CustomerMinified expectedCustomer = new()
        {
            ID = "id",
            ExternalCustomerID = "external_customer_id",
        };
        string expectedDescription = "description";
        double expectedEndingBalance = 0;
        ApiEnum<string, VoidInitiatedLedgerEntryEntryStatus> expectedEntryStatus =
            VoidInitiatedLedgerEntryEntryStatus.Committed;
        ApiEnum<string, VoidInitiatedLedgerEntryEntryType> expectedEntryType =
            VoidInitiatedLedgerEntryEntryType.VoidInitiated;
        long expectedLedgerSequenceNumber = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        DateTimeOffset expectedNewBlockExpiryDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        double expectedStartingBalance = 0;
        double expectedVoidAmount = 0;
        string expectedVoidReason = "void_reason";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCreditBlock, model.CreditBlock);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomer, model.Customer);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedEndingBalance, model.EndingBalance);
        Assert.Equal(expectedEntryStatus, model.EntryStatus);
        Assert.Equal(expectedEntryType, model.EntryType);
        Assert.Equal(expectedLedgerSequenceNumber, model.LedgerSequenceNumber);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedNewBlockExpiryDate, model.NewBlockExpiryDate);
        Assert.Equal(expectedStartingBalance, model.StartingBalance);
        Assert.Equal(expectedVoidAmount, model.VoidAmount);
        Assert.Equal(expectedVoidReason, model.VoidReason);
    }
}
