using System.Text.Json;
using Orb.Core;
using Orb.Models.Events;

namespace Orb.Tests.Models.Events;

public class EventUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EventUpdateResponse { Amended = "amended" };

        string expectedAmended = "amended";

        Assert.Equal(expectedAmended, model.Amended);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EventUpdateResponse { Amended = "amended" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EventUpdateResponse { Amended = "amended" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EventUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAmended = "amended";

        Assert.Equal(expectedAmended, deserialized.Amended);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EventUpdateResponse { Amended = "amended" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EventUpdateResponse { Amended = "amended" };

        EventUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
