using System.Text.Json;
using Orb.Core;
using Orb.Models;

namespace Orb.Tests.Models;

public class PackageConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PackageConfig { PackageAmount = "package_amount", PackageSize = 1 };

        string expectedPackageAmount = "package_amount";
        long expectedPackageSize = 1;

        Assert.Equal(expectedPackageAmount, model.PackageAmount);
        Assert.Equal(expectedPackageSize, model.PackageSize);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PackageConfig { PackageAmount = "package_amount", PackageSize = 1 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PackageConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PackageConfig { PackageAmount = "package_amount", PackageSize = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PackageConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPackageAmount = "package_amount";
        long expectedPackageSize = 1;

        Assert.Equal(expectedPackageAmount, deserialized.PackageAmount);
        Assert.Equal(expectedPackageSize, deserialized.PackageSize);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PackageConfig { PackageAmount = "package_amount", PackageSize = 1 };

        model.Validate();
    }
}
