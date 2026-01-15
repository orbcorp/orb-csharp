using System;
using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class FixedFeeQuantityScheduleEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FixedFeeQuantityScheduleEntry
        {
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceID = "price_id",
            Quantity = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPriceID = "price_id";
        double expectedQuantity = 0;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.Equal(expectedPriceID, model.PriceID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FixedFeeQuantityScheduleEntry
        {
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceID = "price_id",
            Quantity = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FixedFeeQuantityScheduleEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FixedFeeQuantityScheduleEntry
        {
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceID = "price_id",
            Quantity = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FixedFeeQuantityScheduleEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedPriceID = "price_id";
        double expectedQuantity = 0;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.Equal(expectedPriceID, deserialized.PriceID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FixedFeeQuantityScheduleEntry
        {
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PriceID = "price_id",
            Quantity = 0,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}
