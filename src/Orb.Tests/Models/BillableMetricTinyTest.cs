using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class BillableMetricTinyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillableMetricTiny { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillableMetricTiny { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillableMetricTiny>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillableMetricTiny { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillableMetricTiny>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillableMetricTiny { ID = "id" };

        model.Validate();
    }
}
