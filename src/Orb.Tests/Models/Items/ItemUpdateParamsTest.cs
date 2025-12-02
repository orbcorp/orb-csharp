using System.Text.Json;
using Orb.Core;
using Orb.Models.Items;

namespace Orb.Tests.Models.Items;

public class ExternalConnectionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ExternalConnection
        {
            ExternalConnectionName = ExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        ApiEnum<string, ExternalConnectionName> expectedExternalConnectionName =
            ExternalConnectionName.Stripe;
        string expectedExternalEntityID = "external_entity_id";

        Assert.Equal(expectedExternalConnectionName, model.ExternalConnectionName);
        Assert.Equal(expectedExternalEntityID, model.ExternalEntityID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ExternalConnection
        {
            ExternalConnectionName = ExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExternalConnection>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ExternalConnection
        {
            ExternalConnectionName = ExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ExternalConnection>(json);
        Assert.NotNull(deserialized);

        ApiEnum<string, ExternalConnectionName> expectedExternalConnectionName =
            ExternalConnectionName.Stripe;
        string expectedExternalEntityID = "external_entity_id";

        Assert.Equal(expectedExternalConnectionName, deserialized.ExternalConnectionName);
        Assert.Equal(expectedExternalEntityID, deserialized.ExternalEntityID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ExternalConnection
        {
            ExternalConnectionName = ExternalConnectionName.Stripe,
            ExternalEntityID = "external_entity_id",
        };

        model.Validate();
    }
}
