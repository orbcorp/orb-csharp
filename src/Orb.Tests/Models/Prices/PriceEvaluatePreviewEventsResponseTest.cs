using System.Collections.Generic;
using Orb.Models.Prices;

namespace Orb.Tests.Models.Prices;

public class PriceEvaluatePreviewEventsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluatePreviewEventsResponse
        {
            Data =
            [
                new()
                {
                    Currency = "currency",
                    PriceGroups =
                    [
                        new()
                        {
                            Amount = "amount",
                            GroupingValues = ["string"],
                            Quantity = 0,
                        },
                    ],
                    ExternalPriceID = "external_price_id",
                    InlinePriceIndex = 0,
                    PriceID = "price_id",
                },
            ],
        };

        List<DataModel> expectedData =
        [
            new()
            {
                Currency = "currency",
                PriceGroups =
                [
                    new()
                    {
                        Amount = "amount",
                        GroupingValues = ["string"],
                        Quantity = 0,
                    },
                ],
                ExternalPriceID = "external_price_id",
                InlinePriceIndex = 0,
                PriceID = "price_id",
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }
}

public class DataModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataModel
        {
            Currency = "currency",
            PriceGroups =
            [
                new()
                {
                    Amount = "amount",
                    GroupingValues = ["string"],
                    Quantity = 0,
                },
            ],
            ExternalPriceID = "external_price_id",
            InlinePriceIndex = 0,
            PriceID = "price_id",
        };

        string expectedCurrency = "currency";
        List<EvaluatePriceGroup> expectedPriceGroups =
        [
            new()
            {
                Amount = "amount",
                GroupingValues = ["string"],
                Quantity = 0,
            },
        ];
        string expectedExternalPriceID = "external_price_id";
        long expectedInlinePriceIndex = 0;
        string expectedPriceID = "price_id";

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedPriceGroups.Count, model.PriceGroups.Count);
        for (int i = 0; i < expectedPriceGroups.Count; i++)
        {
            Assert.Equal(expectedPriceGroups[i], model.PriceGroups[i]);
        }
        Assert.Equal(expectedExternalPriceID, model.ExternalPriceID);
        Assert.Equal(expectedInlinePriceIndex, model.InlinePriceIndex);
        Assert.Equal(expectedPriceID, model.PriceID);
    }
}
