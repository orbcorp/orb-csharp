using System;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class FixedFeeQuantityTransitionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceID = "price_id",
            Quantity = 0,
        };

        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPriceID = "price_id";
        long expectedQuantity = 0;

        Assert.Equal(expectedEffectiveDate, model.EffectiveDate);
        Assert.Equal(expectedPriceID, model.PriceID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceID = "price_id",
            Quantity = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FixedFeeQuantityTransition>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceID = "price_id",
            Quantity = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FixedFeeQuantityTransition>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPriceID = "price_id";
        long expectedQuantity = 0;

        Assert.Equal(expectedEffectiveDate, deserialized.EffectiveDate);
        Assert.Equal(expectedPriceID, deserialized.PriceID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FixedFeeQuantityTransition
        {
            EffectiveDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceID = "price_id",
            Quantity = 0,
        };

        model.Validate();
    }
}
