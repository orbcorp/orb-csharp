using System.Text.Json;
using Orb.Core;
using Orb.Models.LicenseTypes;

namespace Orb.Tests.Models.LicenseTypes;

public class LicenseTypeCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LicenseTypeCreateResponse
        {
            ID = "id",
            GroupingKey = "grouping_key",
            Name = "name",
        };

        string expectedID = "id";
        string expectedGroupingKey = "grouping_key";
        string expectedName = "name";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedGroupingKey, model.GroupingKey);
        Assert.Equal(expectedName, model.Name);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LicenseTypeCreateResponse
        {
            ID = "id",
            GroupingKey = "grouping_key",
            Name = "name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseTypeCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LicenseTypeCreateResponse
        {
            ID = "id",
            GroupingKey = "grouping_key",
            Name = "name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LicenseTypeCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedGroupingKey = "grouping_key";
        string expectedName = "name";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedGroupingKey, deserialized.GroupingKey);
        Assert.Equal(expectedName, deserialized.Name);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LicenseTypeCreateResponse
        {
            ID = "id",
            GroupingKey = "grouping_key",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LicenseTypeCreateResponse
        {
            ID = "id",
            GroupingKey = "grouping_key",
            Name = "name",
        };

        LicenseTypeCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
