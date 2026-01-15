using System.Text.Json;
using Orb.Core;
using Orb.Models.TopLevel;

namespace Orb.Tests.Models.TopLevel;

public class TopLevelPingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopLevelPingResponse { Response = "response" };

        string expectedResponse = "response";

        Assert.Equal(expectedResponse, model.Response);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopLevelPingResponse { Response = "response" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopLevelPingResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopLevelPingResponse { Response = "response" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopLevelPingResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedResponse = "response";

        Assert.Equal(expectedResponse, deserialized.Response);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopLevelPingResponse { Response = "response" };

        model.Validate();
    }
}
