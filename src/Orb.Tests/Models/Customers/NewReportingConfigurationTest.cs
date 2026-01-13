using System.Text.Json;
using Orb.Core;
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewReportingConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NewReportingConfiguration { Exempt = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NewReportingConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
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
