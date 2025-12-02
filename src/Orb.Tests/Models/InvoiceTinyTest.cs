using System.Text.Json;
using Orb.Models;

namespace Orb.Tests.Models;

public class InvoiceTinyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InvoiceTiny { ID = "gXcsPTVyC4YZa3Sc" };

        string expectedID = "gXcsPTVyC4YZa3Sc";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InvoiceTiny { ID = "gXcsPTVyC4YZa3Sc" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InvoiceTiny>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InvoiceTiny { ID = "gXcsPTVyC4YZa3Sc" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InvoiceTiny>(json);
        Assert.NotNull(deserialized);

        string expectedID = "gXcsPTVyC4YZa3Sc";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InvoiceTiny { ID = "gXcsPTVyC4YZa3Sc" };

        model.Validate();
    }
}
