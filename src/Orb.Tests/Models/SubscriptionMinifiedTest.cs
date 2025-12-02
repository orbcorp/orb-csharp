using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class SubscriptionMinifiedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionMinified { ID = "VDGsT23osdLb84KD" };

        string expectedID = "VDGsT23osdLb84KD";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionMinified { ID = "VDGsT23osdLb84KD" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionMinified>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionMinified { ID = "VDGsT23osdLb84KD" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SubscriptionMinified>(json);
        Assert.NotNull(deserialized);

        string expectedID = "VDGsT23osdLb84KD";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionMinified { ID = "VDGsT23osdLb84KD" };

        model.Validate();
    }
}
