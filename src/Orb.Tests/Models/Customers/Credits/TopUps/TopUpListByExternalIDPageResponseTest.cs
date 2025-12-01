using System.Collections.Generic;
using Orb.Core;
using Orb.Models;
using Orb.Models.Customers.Credits.TopUps;

namespace Orb.Tests.Models.Customers.Credits.TopUps;

public class TopUpListByExternalIDPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopUpListByExternalIDPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = "amount",
                    Currency = "currency",
                    InvoiceSettings = new()
                    {
                        AutoCollection = true,
                        NetTerms = 0,
                        Memo = "memo",
                        RequireSuccessfulPayment = true,
                    },
                    PerUnitCostBasis = "per_unit_cost_basis",
                    Threshold = "threshold",
                    ExpiresAfter = 0,
                    ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
                },
            ],
            PaginationMetadata = new() { HasMore = true, NextCursor = "next_cursor" },
        };

        List<DataModel> expectedData =
        [
            new()
            {
                ID = "id",
                Amount = "amount",
                Currency = "currency",
                InvoiceSettings = new()
                {
                    AutoCollection = true,
                    NetTerms = 0,
                    Memo = "memo",
                    RequireSuccessfulPayment = true,
                },
                PerUnitCostBasis = "per_unit_cost_basis",
                Threshold = "threshold",
                ExpiresAfter = 0,
                ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
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

public class DataModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataModel
        {
            ID = "id",
            Amount = "amount",
            Currency = "currency",
            InvoiceSettings = new()
            {
                AutoCollection = true,
                NetTerms = 0,
                Memo = "memo",
                RequireSuccessfulPayment = true,
            },
            PerUnitCostBasis = "per_unit_cost_basis",
            Threshold = "threshold",
            ExpiresAfter = 0,
            ExpiresAfterUnit = DataModelExpiresAfterUnit.Day,
        };

        string expectedID = "id";
        string expectedAmount = "amount";
        string expectedCurrency = "currency";
        TopUpInvoiceSettings expectedInvoiceSettings = new()
        {
            AutoCollection = true,
            NetTerms = 0,
            Memo = "memo",
            RequireSuccessfulPayment = true,
        };
        string expectedPerUnitCostBasis = "per_unit_cost_basis";
        string expectedThreshold = "threshold";
        long expectedExpiresAfter = 0;
        ApiEnum<string, DataModelExpiresAfterUnit> expectedExpiresAfterUnit =
            DataModelExpiresAfterUnit.Day;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedInvoiceSettings, model.InvoiceSettings);
        Assert.Equal(expectedPerUnitCostBasis, model.PerUnitCostBasis);
        Assert.Equal(expectedThreshold, model.Threshold);
        Assert.Equal(expectedExpiresAfter, model.ExpiresAfter);
        Assert.Equal(expectedExpiresAfterUnit, model.ExpiresAfterUnit);
    }
}
