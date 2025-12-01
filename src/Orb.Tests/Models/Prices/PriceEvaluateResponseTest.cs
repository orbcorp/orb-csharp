using System.Collections.Generic;
using Orb.Models.Prices;

namespace Orb.Tests.Models.Prices;

public class PriceEvaluateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PriceEvaluateResponse
        {
            Data =
            [
                new()
                {
                    Amount = "amount",
                    GroupingValues = ["string"],
                    Quantity = 0,
                },
            ],
        };

        List<EvaluatePriceGroup> expectedData =
        [
            new()
            {
                Amount = "amount",
                GroupingValues = ["string"],
                Quantity = 0,
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }
}
