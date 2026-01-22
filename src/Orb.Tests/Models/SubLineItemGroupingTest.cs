using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class SubLineItemGroupingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubLineItemGrouping { Key = "region", Value = "west" };

        string expectedKey = "region";
        string expectedValue = "west";

        Assert.Equal(expectedKey, model.Key);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubLineItemGrouping { Key = "region", Value = "west" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubLineItemGrouping>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubLineItemGrouping { Key = "region", Value = "west" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubLineItemGrouping>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedKey = "region";
        string expectedValue = "west";

        Assert.Equal(expectedKey, deserialized.Key);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubLineItemGrouping { Key = "region", Value = "west" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubLineItemGrouping { Key = "region", Value = "west" };

        SubLineItemGrouping copied = new(model);

        Assert.Equal(model, copied);
    }
}
