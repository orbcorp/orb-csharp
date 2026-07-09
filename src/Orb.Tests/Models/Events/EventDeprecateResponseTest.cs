using System.Text.Json;
using Orb.Core;
using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventDeprecateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventDeprecateResponse { Deprecated = "deprecated" };

        string expectedDeprecated = "deprecated";

        Assert.Equal(expectedDeprecated, model.Deprecated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventDeprecateResponse { Deprecated = "deprecated" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventDeprecateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventDeprecateResponse { Deprecated = "deprecated" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventDeprecateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDeprecated = "deprecated";

        Assert.Equal(expectedDeprecated, deserialized.Deprecated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventDeprecateResponse { Deprecated = "deprecated" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventDeprecateResponse { Deprecated = "deprecated" };

        EventDeprecateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
