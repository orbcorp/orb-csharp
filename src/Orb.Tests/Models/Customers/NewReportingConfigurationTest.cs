using System.Text.Json;
using Orb.Models.Customers;

namespace Orb.Tests.Models.Customers;

public class NewReportingConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NewReportingConfiguration { Exempt = true };

        bool expectedExempt = true;

        Assert.Equal(expectedExempt, model.Exempt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NewReportingConfiguration { Exempt = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewReportingConfiguration>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewReportingConfiguration { Exempt = true };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NewReportingConfiguration>(json);
        Assert.NotNull(deserialized);

        bool expectedExempt = true;

        Assert.Equal(expectedExempt, deserialized.Exempt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NewReportingConfiguration { Exempt = true };

        model.Validate();
    }
}
