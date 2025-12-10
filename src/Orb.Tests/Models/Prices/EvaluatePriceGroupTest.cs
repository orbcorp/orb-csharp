using System.Collections.Generic;
using System.Text.Json;
using Orb.Models.Prices;

namespace Orb.Tests.Models.Prices;

public class EvaluatePriceGroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EvaluatePriceGroup
        {
            Amount = "amount",
            GroupingValues = ["string"],
            Quantity = 0,
        };

        string expectedAmount = "amount";
        List<GroupingValue> expectedGroupingValues = ["string"];
        double expectedQuantity = 0;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedGroupingValues.Count, model.GroupingValues.Count);
        for (int i = 0; i < expectedGroupingValues.Count; i++)
        {
            Assert.Equal(expectedGroupingValues[i], model.GroupingValues[i]);
        }
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EvaluatePriceGroup
        {
            Amount = "amount",
            GroupingValues = ["string"],
            Quantity = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EvaluatePriceGroup>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EvaluatePriceGroup
        {
            Amount = "amount",
            GroupingValues = ["string"],
            Quantity = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<EvaluatePriceGroup>(json);
        Assert.NotNull(deserialized);

        string expectedAmount = "amount";
        List<GroupingValue> expectedGroupingValues = ["string"];
        double expectedQuantity = 0;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedGroupingValues.Count, deserialized.GroupingValues.Count);
        for (int i = 0; i < expectedGroupingValues.Count; i++)
        {
            Assert.Equal(expectedGroupingValues[i], deserialized.GroupingValues[i]);
        }
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EvaluatePriceGroup
        {
            Amount = "amount",
            GroupingValues = ["string"],
            Quantity = 0,
        };

        model.Validate();
    }
}

public class GroupingValueTest : TestBase
{
    [Fact]
    public void stringValidation_Works()
    {
        GroupingValue value = new("string");
        value.Validate();
    }

    [Fact]
    public void doubleValidation_Works()
    {
        GroupingValue value = new(0);
        value.Validate();
    }

    [Fact]
    public void boolValidation_Works()
    {
        GroupingValue value = new(true);
        value.Validate();
    }

    [Fact]
    public void stringSerializationRoundtrip_Works()
    {
        GroupingValue value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<GroupingValue>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void doubleSerializationRoundtrip_Works()
    {
        GroupingValue value = new(0);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<GroupingValue>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void boolSerializationRoundtrip_Works()
    {
        GroupingValue value = new(true);
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<GroupingValue>(json);

        Assert.Equal(value, deserialized);
    }
}
