using System.Collections.Generic;
using System.Text.Json;
using Orb.Core;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEvaluateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PriceEvaluateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<EvaluatePriceGroup> expectedData =
        [
            new()
            {
                Amount = "amount",
                GroupingValues = ["string"],
                Quantity = 0,
            },
        ];

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }
}
